import { useQuery } from "@tanstack/react-query";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { MainSection } from "../components/MainSection";
import { MyFooter } from "../components/MyFooter";
import { Nav } from "../components/Nav";
import { ClaimsContext } from "../components/ClaimsContext";
import { useContext } from "react";
import { getEventsByAuthor } from "../api/config/services/eventService";
import ThereIsNothingToRender from "../components/ThereIsNothingToRender";
import { EventCard } from "../components/EventCard";
import type { EventByAuthor } from "../types/globalTypes";

export default function SelectEventForEdition() {
  const claims = useContext(ClaimsContext);

  const { data: eventsByAuthor } = useQuery({
    queryKey: ["eventsByAuthor", claims?.memberId],
    enabled: claims?.memberId != null,
    queryFn: () => {
      if(claims != undefined) return getEventsByAuthor(claims?.memberId);
    },
  });

  const eventsList = eventsByAuthor.map((eventItem: EventByAuthor) =>{
    return(
      <EventCard 
        date={eventItem.beginningOfEvent}
        description={eventItem.title}
        eventId={String(eventItem.eventId)}
      ></EventCard>
    );
  });

  return (
    <MainBackgroundDiv>
      <Nav title="Selecione o evento"></Nav>
      <MainSection>
        {eventsByAuthor && eventsByAuthor?.length < 1 ? (
          <ThereIsNothingToRender title="Você não tem eventos futuros marcados" />
        ) : (
          eventsList
        )}
      </MainSection>
      <MyFooter></MyFooter>
    </MainBackgroundDiv>
  );
}
