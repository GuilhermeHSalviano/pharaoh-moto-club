import styled from "styled-components";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import MainCentralCard from "../components/MainCentralCard";
import { MainSection } from "../components/MainSection";
import { MyFooter } from "../components/MyFooter";
import { Nav } from "../components/Nav";
import { fonts } from "../styles/fonts";
import { colors } from "../styles/colors";
import { MyInput } from "../components/Input";
import { useContext, useState } from "react";
import {
  getCitiesFromIbgeById,
  getStatesFromIbge,
} from "../api/config/services/ibgeService";
import { useQuery } from "@tanstack/react-query";
import { createNewEvent, getTypesOfEvent } from "../api/config/services/eventService";
import "react-datepicker/dist/react-datepicker.css";
import { genericInput } from "../styles/sizes";
import { MainButton } from "../components/MainButton";
import type { MyJwtPayload, NewEvent, CityFromIbge, TypeOfEvent } from "../types/globalTypes";
import { jwtDecode } from "jwt-decode";
import { TokenContext } from "../components/TokenContext";
import { useNavigate } from "react-router";

export default function CreateEvent() {
  const [, setTitleInput] = useState("");
  const [selectedState, setSelectedState] = useState("MG");
  const [cityInput, setCityInput] = useState("");
  const [cityId, setCityId] = useState<number>();
  const [isCityOptionsVisible, setIsCityOptionsVisible] = useState(false);
  const [dateTimeInput, setDateTimeInput] = useState("");
  const [eventDescriptionInput, setEventDescriptionInput] = useState("");
  const [typeOfEventId, setTypeOfEventId] = useState<number>(13);
  const token: MyJwtPayload = jwtDecode(useContext(TokenContext));
  const navigate = useNavigate()


  function changeCityOptionsVisibility() {
    setIsCityOptionsVisible(!isCityOptionsVisible);
  }

  function verifyWhetherAnyFormFieldIsFilled(){
    let formField = [
      {
        field: titleInput,
        message: "Preencha o título do evento"
      },
      {
        field: cityInput,
        message: "Selecione uma cidade"
      },
      {
        field: dateTimeInput,
        message: "Selecione uma data e horário"
      },
      {
        field: dateTimeInput,
        message: "Informe a descrição do evento"
      }
    ]

      for(let i = 0; i < formField.length; i++){
        if(formField[i].field === "") {
          alert(formField[i].message);
          throw new Error(formField[i].message)
        }        
    }
    
  }

  function saveNewEvent(){
    verifyWhetherAnyFormFieldIsFilled();

    let newEvent: NewEvent = {
      title: titleInput,
      state: selectedState,
      stateId: Number(statesFromIbge?.find(element => element.sigla == selectedState)?.id),
      city: cityInput,
      cityId: Number(cityId),
      beginningOfEvent: new Date(dateTimeInput),
      description: eventDescriptionInput,
      authorId: Number(token.nameid),
      authorName: token.name,
      typeOfEventId: Number(typeOfEventId) 
    }
    createNewEvent(newEvent);
    alert('Novo evento criado com sucesso!');
    navigate("/dashboard");
    
  }

  const { data: statesFromIbge } = useQuery({
    queryKey: ["statesFromIbge"],
    queryFn: () => {
      return getStatesFromIbge();
    },
  });

  let state = statesFromIbge?.find((state) => state.sigla == selectedState);

  let { data: citiesFromIbge } = useQuery({
    queryKey: ["citiesFromIbge", selectedState],
    enabled: !!state,
    queryFn: () => {
      if (state) return getCitiesFromIbgeById(state.id);
    },
  });

  let { data: typesOfEvent } = useQuery({
    queryKey: ["typesOfEvent"],
    queryFn: () => {
      return getTypesOfEvent();
    },
  });

  const filteredCities = citiesFromIbge?.filter(
    (city: CityFromIbge) =>
      city.nome.toLowerCase().includes(cityInput.toLowerCase()),
  );

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
          <GeneralHorizontalContainer>
            <StateInputContainer>
              <StateAndCity>{"Estado"}</StateAndCity>
              <Select
                value={selectedState}
                onChange={(event) => {
                  setSelectedState(event.target.value);
                  setIsCityOptionsVisible(false);
                }}
              >
                {statesFromIbge?.map((state) => (
                  <Option value={state.sigla} key={state.id}>
                    {state?.sigla}
                  </Option>
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
                  filteredCities&&
                  filteredCities?.length <= 5 && isCityOptionsVisible == true
                  ? filteredCities.map((city) => (
                      <City
                        onClick={() => {
                          setCityInput(city.nome);
                          setCityId(city.id)
                          changeCityOptionsVisibility();
                        }}
                      >
                        {city.nome}
                      </City>
                    ))
                  : ""
                }
              </CitiesContainer>
            </CityInputAndSelectContainer>
          </GeneralHorizontalContainer>
          <GeneralVerticalContainer>
            <TypeOfEventContainer>
              <Title>Tipo de evento</Title>
              <Select value={typeOfEventId}
                onChange={event => setTypeOfEventId(Number(event.target.value))}
              >
                {typesOfEvent?.map((type: TypeOfEvent) => (
                  <Option value={type?.typeOfEventId} key={type.typeOfEventId}>
                    {type?.description}
                  </Option>
                ))}
              </Select>
            </TypeOfEventContainer>
            <DateTimeContainer>
              <Title>Data do evento</Title>
              <DateTimeInput
                type="datetime-local"
                onChange={event => setDateTimeInput(event.target.value)}
              ></DateTimeInput>
            </DateTimeContainer>
          </GeneralVerticalContainer>
          <DescriptionContainer>
            <Title>Descrição</Title>
            <Description
              style={{  ...genericInput, height: "4rem" }}
              placeholder="Descreva o evento..."
              onChange={event => setEventDescriptionInput(event.target.value)}
              name="description"
            ></Description>
          </DescriptionContainer>
        </MainCentralCard>
        <MainButtonContainer>
            <MainButton title="Salvar" doOnClick={()=> saveNewEvent()}/>
        </MainButtonContainer>
      </MainSection>
      <MyFooter></MyFooter>
    </MainBackgroundDiv>
  );
}

const TitleInputContainer = styled.div`
  display: flex;
  flex-wrap: wrap;
  margin-bottom: 1em;
  padding: 1em 1em 0 1em;
  width: 100%;
`;

const Title = styled.h2`
  align-self: flex-start;
  color: ${colors.titleInDarkBackground};
  font-family: ${fonts.labelFont};
  font-size: 1.5em;
  width: 100%;
`;

const GeneralHorizontalContainer = styled.div`
  display: flex;
  justify-content: space-around;
`;

const GeneralVerticalContainer = styled.div`
  align-items: center;
  display: flex;
  flex-direction: column;
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

const CityInputContainer = styled.div``;

const CitiesContainer = styled.div`
  display: flex;
  flex-direction: column;
`;

const City = styled.div`
  background-color: aliceblue;
  font-family: ${fonts.cardFont};
`;

const TypeOfEventContainer = styled.div`
  margin: 1rem 0 1rem 0;
`;

const DateTimeContainer = styled.div``;

const DescriptionContainer = styled.div`
  display: flex;
  flex-direction: column;
  flex-grow: 1;
  padding: 0 2rem 2rem 2rem;
  margin-top: 1rem;
`;

const DateTimeInput = styled.input`
  font-family: ${fonts.cardFont};
`;

const Description = styled.textarea`
  &::placeholder {
    ${genericInput.placeholder}
  }
  &:focus {
    ${genericInput.focus}
  }
  &:not {
    ${genericInput.not}
  }
`;

const MainButtonContainer = styled.div`
  display: flex;
  flex-grow: 1;
  justify-content: center;
  margin: 2rem 0 2rem 0;
  width: 100%;
`
