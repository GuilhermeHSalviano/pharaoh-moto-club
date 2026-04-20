import styled from "styled-components";
import { colors } from "../styles/colors";
import { getDay, getMonth } from "../utilFunctions";
import { fonts } from "../styles/fonts";
import { sizes } from "../styles/sizes";
import goButton from "../assets/go.png"
import { useNavigate } from "react-router";

interface Event {
  date: Date;
  description: string;
  eventId: string
}

export function EventCard({ date, description, eventId }: Event) {
  const navigate = useNavigate();

  return (
    <EventContainer onClick={() => navigate(`/event/${eventId}`)}>
      <DateContainer>
        <DateNumber>{getDay(date)}</DateNumber>
      </DateContainer>
      <MonthContainer>
        <Month>{getMonth(date).toUpperCase()}</Month>
      </MonthContainer>
      <DescriptionContainer>
        <Description>{description}</Description>
      </DescriptionContainer>
      <GoButton src={goButton}></GoButton>
    </EventContainer>
  );
}

const EventContainer = styled.div`
  align-items: center;
  background-color: ${colors.inputBackground};
  border-radius: 1rem;
  box-shadow: ${sizes.dashboardCardShadow};
  display: flex;
  height: 5rem;
  margin: 1rem 0 1rem 0;
  width: 75%;
`;

const DateContainer = styled.div`
  align-items: flex-start;
  display: flex;
  justify-content: center;
  width: 20%;
`;

const DescriptionContainer = styled.div`
  flex-direction: column;
  display: flex;
  width: 60%;
`;

const Description = styled.p`
    color: white;
    font-family: ${fonts.citiesFont};
    padding-left: 3px;
`

const DateNumber = styled.p`
  color: ${colors.mainButtonBackground};
  font-size: 3.5rem;
  font-family: ${fonts.dateNumber};
  font-weight: 600;
  margin-left: 1rem;
`;

const MonthContainer = styled.div`
  align-items: center;
  border-right: solid 2px white;
  display: flex;
  flex-direction: column;

  height: 80%;
  justify-content: center;
`;

const Month = styled.p`
  color: ${colors.mainButtonBackground};
  font-family: ${fonts.cardFont};
  transform: rotate(-90deg);
`;

const GoButton = styled.img`
    
`
