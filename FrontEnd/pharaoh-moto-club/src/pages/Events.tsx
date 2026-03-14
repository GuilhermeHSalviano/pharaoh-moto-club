import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import styled from "styled-components";
import { sizes } from "../styles/sizes";
import axios from "axios";
import { useQuery } from "@tanstack/react-query";

interface StatesAndCities {
  state: string;
  stateId: number;
  cities: [{ city: string; cityId: number }];
}

export function Events() {
  const baseURL = import.meta.env.VITE_API_URL;

  async function getStatesAndCities() {
    try {
      console.log("teste");
      return await axios.get<StatesAndCities>(`${baseURL}/events/states`);
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



  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"Eventos por estado"}></Nav>
            <MainSection></MainSection>
            <MyFooter></MyFooter>
          </>
        }
      </MainBackgroundDiv>
    </>
  );
}

const MainSection = styled.section`
  min-height: ${sizes.mainSection};
  width: 100%;
`;
