import styled from "styled-components";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import MainCentralCard from "../components/MainCentralCard";
import { MainSection } from "../components/MainSection";
import { MyFooter } from "../components/MyFooter";
import { Nav } from "../components/Nav";
import { fonts } from "../styles/fonts";
import { colors } from "../styles/colors";
import { MyInput } from "../components/Input";
import { useState } from "react";
import { getCitiesFromIbgeById, getStatesFromIbge } from "../api/config/services/ibgeService";
import { useQuery } from "@tanstack/react-query";
import { getTypesOfEvent } from "../api/config/services/eventService";
import "react-datepicker/dist/react-datepicker.css";

export default function CreateEvent() {
  const [, setTitleInput] = useState("");
  const [selectedState, setSelectedState] = useState("MG");
  const [cityInput, setCityInput] = useState("");
  const [isCityOptionsVisible, setIsCityOptionsVisible] = useState(false);
  const [dateTimeInput, ] = useState();
  const [eventDescription, setEventDescription] = useState('');

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

  interface TypeOfEvent{
    typeOfEventId: number,
    description: string
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

  let { data: typesOfEvent} = useQuery({
    queryKey: ["typesOfEvent"],
    queryFn: () => {
        return getTypesOfEvent();
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
          <GeneralContainer>
            <StateInputContainer>
              <StateAndCity>{"Estado"}</StateAndCity>
              <Select
                value={selectedState}
                onChange={(event) => { setSelectedState(event.target.value); setIsCityOptionsVisible(false) }}
              >
                {statesFromIbge?.map((state) => (
                  <Option value={state.sigla} key={state.id}>{state?.sigla}</Option>
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
          </GeneralContainer>
          <GeneralContainer>
            <TypeOfEventContainer>
              <Title>Tipo de evento</Title>
              <Select
                value={typesOfEvent?.description}
              >
                {typesOfEvent?.map((type: TypeOfEvent) => (
                  <Option value={type?.description} key={type.typeOfEventId}>{type?.description}</Option>
                ))}
              </Select>
            </TypeOfEventContainer>
            <DateTimeContainer>
              <Title>Data do evento</Title>
              <DateTimeInput
                type="datetime-local"
                value={dateTimeInput}
              ></DateTimeInput>
            </DateTimeContainer>
          </GeneralContainer>
          <DescriptionContainer>
            <Title>Descrição</Title>
            <MyInput
              setValue={setEventDescription}
                placeholder="Descrição..."
                width="100%"
                height="60%"
                name="description"
                id="description"
                type="textarea"
                value={eventDescription}
            ></MyInput>
          </DescriptionContainer>
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

const GeneralContainer = styled.div`
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
  width: 7em;
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

const TypeOfEventContainer = styled.div`

`

const DateTimeContainer = styled.div`
  
`

const DescriptionContainer = styled.div`
  display: flex;
  flex-direction: column;
  flex-grow: 1;
  padding: 0 2rem 2rem 2rem;
  margin-top: 1rem;
`

const DateTimeInput = styled.input`
  font-family: ${fonts.cardFont};
`



