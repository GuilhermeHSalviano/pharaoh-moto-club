import styled from "styled-components";
import { colors } from "../styles/colors";
import type { State } from "../interfaces.tsx";
import { useState } from "react";
import { fonts } from "../styles/fonts.tsx";
import { sizes } from "../styles/sizes.tsx";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGreaterThan } from "@fortawesome/free-solid-svg-icons";
import {useNavigate } from "react-router";


export function StateContainer({ state, stateId, cities }: State) {
  const [visible, setVisible] = useState(false);
  const [changeDisplayIcon, setchangeDisplayIcon] = useState("inline");
  const [containerBackgroundColor, setcontainerBackgroundColor] = useState(colors.inputBackground);
  const navigate = useNavigate();

  const toggleCities = () => {
    if (visible) {
      return cities.map((city) => {
        return (
          <CityContainer key={city.city}>
            <CityName onClick={()=> navigate(`/event/${city.city}`)}>{city.city}</CityName>
            <GreaterThan icon={faGreaterThan}></GreaterThan>
          </CityContainer>
        );
      });
    }
  };

  function changeStyles () {
    switch(visible){
      case false:
        setchangeDisplayIcon("none");
        setcontainerBackgroundColor(colors.selectedCard);
      break;
      case true:
        setchangeDisplayIcon("inline");
        setcontainerBackgroundColor(colors.inputBackground);
      break;
    }

  }

  return (
    <>
      <Container onClick={() => {setVisible(!visible); changeStyles()}} style={{backgroundColor: `${containerBackgroundColor}`}}>
        <ContainerState >
          <State>{state}</State>
          <GreaterThan icon={faGreaterThan} style={{display: `${changeDisplayIcon}`}}></GreaterThan>
        </ContainerState>
        <CitiesContainer>{toggleCities()}</CitiesContainer>
      </Container>
    </>
  );
}

const Container = styled.div`
  align-items: center;
  box-shadow: ${sizes.buttonShadow};
  border-radius: 1rem;
  display: flex;
  flex-direction: column;
  justify-content: center;
  margin: 1rem 0 1rem 0;
  min-height: 5rem;
  padding: 1rem 0 1rem 0;
  width: 100%;
`;

const ContainerState = styled.div`
  align-items: center;
  display: flex;
  width: 100%;
`
const GreaterThan = styled(FontAwesomeIcon)`
  color: white;
  font-size: 0.8rem;
  margin-right: 1.5rem;
  transform: rotate(rotateGraterThanIcon);
`

const State = styled.h2`
  color: ${colors.mainButtonBackground};
  font-family: ${fonts.labelFont};
  font-size: 2rem;
  margin-left: 2rem;
  width: 100%;
`;

const CitiesContainer = styled.ul`
  display: flex;
  flex-direction: column;
  margin-left: 5rem;
  width: 70%;
`;

const CityContainer = styled.li`
  align-items: center;
  display: flex;
  justify-content: space-between;
`;

const CityName = styled.h3`
  color: white;
  font-family: ${fonts.citiesFont};
  font-size: 1.2rem;
  margin: 1rem 0 1rem 0;
`;
