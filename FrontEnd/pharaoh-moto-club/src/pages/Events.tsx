import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import styled from "styled-components";
import { sizes } from "../styles/sizes";
import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import { StateContainer } from "../components/StateContainer";
import type { State } from "../interfaces";

export function Events() {
  const baseURL = import.meta.env.VITE_API_URL;

  async function getStatesAndCities() {
    try {
      const result = await axios.get<Array<State>>(`${baseURL}/events/states`);
      return result.data;
    } catch (error) {
      console.log(error);
    }
  }

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
            <MainSection>{StateArray}</MainSection>
            <MyFooter></MyFooter>
          </>
        }
      </MainBackgroundDiv>
    </>
  );
}

const MainSection = styled.section`
  align-items: center;
  display: flex;
  flex-direction: column;
  min-height: ${sizes.mainSection};
  width: 100%;
`;

const StatesContainer = styled.div`
  align-items: center;
  justify-content: center;
  display: flex;
  width: 80%;
`;
