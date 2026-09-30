import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import styled from "styled-components";
import { useQuery } from "@tanstack/react-query";
import { StateContainer } from "../components/StateContainer";
import { MainSection } from "../components/MainSection";
import { getStatesAndCities } from "../api/config/services/eventService";
import { fonts } from "../styles/fonts";
import ThereIsNothingToRender from "../components/ThereIsNothingToRender";

export function Events() {
  const { data: states } = useQuery({
    queryKey: ["states"],
    queryFn: () => {
      return getStatesAndCities();
    },
  });

  const StateArray = states?.map((state) => {
    return (
      <StatesContainer key={state.state}>
        <StateContainer
          state={state.state}
          stateId={state.stateId}
          cities={state.cities}
        ></StateContainer>
      </StatesContainer>
    );
  });

  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"Eventos por estado"}></Nav>
            <MainSection>{
              states &&
              states?.length < 1?
              (
                <ThereIsNothingToRender title="Não há eventos marcados"/>
              ):
              (StateArray)
            }</MainSection>
            <MyFooter></MyFooter>
          </>
        }
      </MainBackgroundDiv>
    </>
  );
}


const StatesContainer = styled.div`
  align-items: center;
  justify-content: center;
  display: flex;
  width: 80%;
`;


