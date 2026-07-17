import styled from "styled-components";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import MainCentralCard from "../components/MainCentralCard";
import { MainSection } from "../components/MainSection";
import { MyFooter } from "../components/MyFooter";
import { Nav } from "../components/Nav";
import { fonts } from "../styles/fonts";
import { colors } from "../styles/colors";
import { MyInput } from "../components/Input";
import { useEffect, useState } from "react";
import { getCitiesFromIbgeById, getStatesFromIbge } from "../api/config/services/ibgeService";
import { useQuery } from "@tanstack/react-query";

export default function CreateEvent() {
  const [titleInput, setTitleInput] = useState("");
  const [selectedState, setSelectedState] = useState("MG");
  const [cityInput, setCityInput] = useState("");
  const [isCityOptionsVisible, setIsCityOptionsVisible] = useState(false);

  interface CitiesFromIbge{
    id: number;
    nome: string;
    sigla: string;
    regiao:{
      id: number;
      nome: string;
      sigla: string
    }
  }


  
  function changeCityOptionsVisibility(){
    setIsCityOptionsVisible(!isCityOptionsVisible);
  }

  const { data: statesFromIbge } = useQuery({
    queryKey: ["statesFromIbge"],
    queryFn: () => {
      return getStatesFromIbge();
    },
  });

  let state = statesFromIbge?.find(state => state.sigla == selectedState);

  let { data: citiesFromIbge} = useQuery({
    queryKey: ["citiesFromIbge", selectedState],
    enabled: !!state,
    queryFn: () => {
        if(state) return getCitiesFromIbgeById(state.id);
    },
  });

  const filteredCities: CitiesFromIbge[] = citiesFromIbge?.filter((city: CitiesFromIbge) => city.nome.toLowerCase().includes(cityInput.toLowerCase()));

  return (
    <MainBackgroundDiv>
      <Nav title="Criar evento"></Nav>
      <MainSection>
        <MainCentralCard>
          <TitleInputContainer>
            <Title>{"Título"}</Title>
            <MyInput
              width={"100%"}
              setValue={setTitleInput}
              type={"text"}
              name={"titleInput"}
              placeholder={"Nome do evento"}
              id={"title"}
            ></MyInput>
          </TitleInputContainer>
          <StateAndCityContainer>
            <StateInputContainer>
              <StateAndCity>{"Estado"}</StateAndCity>
              <Select
                value={selectedState}
                onChange={(event) => { setSelectedState(event.target.value); setIsCityOptionsVisible(false) }}
              >
                {statesFromIbge?.map((state) => (
                  <Option value={state.sigla}>{state?.sigla}</Option>
                ))}
              </Select>
            </StateInputContainer>
            <CityInputAndSelectContainer>
              <StateAndCity>{"Cidade"}</StateAndCity>
              <CityInputContainer onClick={() => setIsCityOptionsVisible(true)}>
                <MyInput
                  setValue={setCityInput}
                  placeholder="Cidade..."
                  width="100%"
                  name="city"
                  id="city"
                  type="text"
                  value={cityInput}
                ></MyInput>
              </CityInputContainer>
              <CitiesContainer>
                {
                  filteredCities?.length <= 5 && isCityOptionsVisible == true ?
                  filteredCities.map(city => (
                    <City 
                      onClick={()=> {setCityInput(city.nome); changeCityOptionsVisibility()}}>{city.nome}
                    </City>
                  )): ""
                }
              </CitiesContainer>
            </CityInputAndSelectContainer>
          </StateAndCityContainer>
        </MainCentralCard>
      </MainSection>
      <MyFooter></MyFooter>
    </MainBackgroundDiv>
  );
}

const TitleInputContainer = styled.div`
  display: flex;
  flex-wrap: wrap;
  margin-bottom: 1em;
  padding: 2em 2em 0 2em;
  width: 100%;
`;

const Title = styled.h2`
  align-self: flex-start;
  color: ${colors.titleInDarkBackground};
  font-family: ${fonts.labelFont};
  font-size: 1.5em;
  width: 100%;
`;

const StateAndCityContainer = styled.div`
  display: flex;
  justify-content: space-around;
`;

const StateInputContainer = styled.div`
  display: flex;
  flex-direction: column;
  margin-bottom: 1em;
  width: 30%;
`;

const StateAndCity = styled.h2`
  align-self: flex-start;
  color: ${colors.titleInDarkBackground};
  font-family: ${fonts.labelFont};
  font-size: 1.5em;
`;

const Select = styled.select`
  font-family: ${fonts.cardFont};
  width: 5em;
`;

const Option = styled.option`
  font-family: ${fonts.cardFont};
  height: 20%;
`;

const CityInputAndSelectContainer = styled.div`
  display: flex;
  flex-direction: column;
  margin-bottom: 1em;
  width: 40%;
`;

const CityInputContainer = styled.div`
  
`


const CitiesContainer = styled.div`
  display: flex;
  flex-direction: column;
`

const City = styled.div`
  background-color: aliceblue;
  font-family: ${fonts.cardFont};
`
