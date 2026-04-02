import { useParams } from "react-router";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import { MainSection } from "../components/MainSection";
import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import styled from "styled-components";
import { colors } from "../styles/colors";
import { fonts } from "../styles/fonts";
import { EventCard } from "../components/EventCard";



export default function SelectedCity() {
const baseURL = import.meta.env.VITE_API_URL;
  let params = useParams();
  console.log(params)

  async function getCityEvents() {
      try {
        const result = await axios.get(`${baseURL}/events/city/${params.city}`);
        return result.data;
      } catch (error) {
        console.log(error);
      }
    }

    const { data: cityEvents } = useQuery({
    queryKey: ["cityEvents"],
    queryFn: () => {
      return getCityEvents();
    },
  });

  const eventsByCity = cityEvents?.map(myEvent => {
    return(
      <EventCard 
        date={myEvent.beginningOfEvent}
        description={myEvent.description}
      ></EventCard>
    )
  })
 
  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"EVENTOS EM "}></Nav>
            <MainSection>{
              <>
                <TitleContainer>
                  <Title>EVENTOS:</Title>
                </TitleContainer>
                {eventsByCity}
              </>
              }</MainSection>
            <MyFooter></MyFooter>
          </>
        }
      </MainBackgroundDiv>
    </>
  );
}

const TitleContainer = styled.div`
  display: flex;
  justify-content: flex-start;
  width: 100%;
`

const Title = styled.h2`
  color: ${colors.mainButtonBackground};
  font-family: ${fonts.labelFont};
  font-size: 2rem;
  margin: 1rem 0 2rem 2rem;
`


