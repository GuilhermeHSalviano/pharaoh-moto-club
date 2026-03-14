import styled from "styled-components";
import { colors } from "../styles/colors";
import type { State } from "../interfaces.tsx";
import { useState } from "react";

export function StateContainer({ state, stateId, cities }: State) {
  const [visible, setVisible] = useState(false);

  const toggleCities = () => {
    if (visible) {
      return cities.map((city) => {
        return (
          <CityContainer key={city.city}>
            <CityName>{city.city}</CityName>
          </CityContainer>
        );
      });
    }
  };

  return (
    <>
      <Container onClick={() => setVisible(!visible)}>
        <State>{state}</State>
        <CitiesContainer>{toggleCities()}</CitiesContainer>
      </Container>
    </>
  );
}

const Container = styled.div`
  align-items: center;
  background-color: ${colors.footerIcons};
  border-radius: 1rem;
  display: flex;
  flex-direction: column;
  justify-content: center;
  margin: 2rem 0 2rem 0;
  min-height: 5rem;
  width: 100%;
`;

const State = styled.h2`
  color: ${colors.mainButtonBackground};
  width: 100%;
`;

const CitiesContainer = styled.ul`
  display: flex;
`;

const CityContainer = styled.li`
  height: 5rem;
`;

const CityName = styled.h3`
  color: white;
`;
