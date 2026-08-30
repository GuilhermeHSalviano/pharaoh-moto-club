import { useLocation, useParams } from "react-router";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import { MainSection } from "../components/MainSection";
import { useQuery } from "@tanstack/react-query";
import styled from "styled-components";
import { colors } from "../styles/colors";
import { fonts } from "../styles/fonts";
import { EventCard } from "../components/EventCard";
import { getCityEvents } from "../api/config/services/eventService";

interface MotoClubEvent{
  beginningOfEvent: Date;
  title: string;
  eventId: string;
}

export default function SelectedCity() {
  let params = useParams();
  let city = useLocation();

  const { data: cityEvents } = useQuery({
    queryKey: ["cityEvents"],
    queryFn: () => {
      return getCityEvents(params.city);
    },
  });

  const eventsByCity = cityEvents?.map((myEvent : MotoClubEvent) => {
    return (
      <EventCard
        key={myEvent.eventId}
        date={myEvent.beginningOfEvent}
        description={myEvent.title}
        eventId = {myEvent.eventId}
      ></EventCard>
    );
  });

  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"EVENTOS EM " + city.state}></Nav>
            <MainSection>
              {
                <>
                  <TitleContainer>
                    <Title>EVENTOS:</Title>
                  </TitleContainer>
                  {eventsByCity}
                </>
              }
            </MainSection>
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
`;

const Title = styled.h2`
  color: ${colors.mainButtonBackground};
  font-family: ${fonts.labelFont};
  font-size: 2rem;
  margin: 1rem 0 2rem 2rem;
`;
