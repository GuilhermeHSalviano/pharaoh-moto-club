import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import styled from "styled-components";
import { sizes } from "../styles/sizes";
import axios from "axios";
import { useEffect, useState } from "react";

interface StatesAndCities{
  state: string,
  stateId: number,
  cities: [{city: string, cityId: number}]
}


export function Events() {
  const [statesAndCities, setStatesAndCities] = useState<StatesAndCities>();
  const baseURL = import.meta.env.VITE_API_URL;
  async function getStatesAndCities() {
    try {
      console.log("teste");
      const result = await axios.get<StatesAndCities>(`${baseURL}/events/states`);
      setStatesAndCities(result.data);
    } catch (error) {
      console.log(error);
    }
  }


  useEffect(() =>{
    getStatesAndCities();
  }, [])

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
function AxiosResponse<T, U, V>() {
  throw new Error("Function not implemented.");
}

