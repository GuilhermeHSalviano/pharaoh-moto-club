import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import { MainSection } from "../components/MainSection";
import { useParams } from "react-router";
import styled from "styled-components";
import { fonts } from "../styles/fonts";
import { colors } from "../styles/colors";
import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import { getDate, getTime } from "../utilFunctions";
import SmallTitle from "../components/SmallTitle";
import type { MyJwtPayload, StyleObject } from "../types/globalTypes";
import { useContext, useState } from "react";
import { jwtDecode } from "jwt-decode";
import { TokenContext } from "../components/TokenContext";
import Loading from "../components/Loading";
import ConfirmAttendanceButton from "../components/ConfirmAttendanceButton";
import SendCommentButton from "../components/SendCommentButton";
import CommentList from "../components/CommentList";

export default function SelectedEvent() {
  const params = useParams();
  const baseURL = import.meta.env.VITE_API_URL;
  const token: MyJwtPayload = jwtDecode(useContext(TokenContext));
  const [commentInput, setCommentInput] = useState("");
  console.log(token);

  async function getEventyById() {
    try {
      const result = await axios.get(`${baseURL}/events/${params.eventId}`);
      return result.data;
    } catch (error) {
      console.log(error);
    }
  }

  const {
    data: eventData,
    isLoading,
    refetch,
  } = useQuery({
    queryKey: ["eventData"],
    queryFn: () => {
      return getEventyById();
    },
  });

  const SmallTitleCustomStyles: Array<StyleObject> = [
    { property: "fontFamily", value: fonts.cardFont },
  ];

  return (
    <MainBackgroundDiv>
      <>
        <Nav title={"Evento"}></Nav>
        <MainSection>
          <>
            {isLoading && <Loading></Loading>}
            <Title>{eventData?.event.title}</Title>
            <DescriptionBaloon>
              <DescriptionTitle>Descrição</DescriptionTitle>
              <Description>{eventData?.event.description}</Description>
              <Author>{`Author: ${eventData?.event.authorName}`}</Author>
            </DescriptionBaloon>
            <TimeAndDateContainer>
              <TimeAndDate>HORÁRIO E DATA DO EVENTO:</TimeAndDate>
              <EventDate>{`${getDate(eventData?.event.beginningOfEvent)} - ${getTime(eventData?.event.beginningOfEvent)}`}</EventDate>
            </TimeAndDateContainer>
            <AttendantsSection>
              <AttendantsContainer>
                <SmallTitle
                  description="Faraós Confirmados:"
                  aditionalStyles={SmallTitleCustomStyles}
                ></SmallTitle>
                {eventData?.attendants.length > 0 ? (
                  eventData.attendants.map((name: string) => (
                    <AttendantName key={name}>{name}</AttendantName>
                  ))
                ) : (
                  <AttendantName>{"Nenhuma presença confirmada"}</AttendantName>
                )}
              </AttendantsContainer>
              <ConfirmAttendanceButton
                memberId={token.nameid}
                eventId={eventData?.event.eventId}
                refetch={refetch}
                hasMemberConfirmedAttendance={eventData?.attendants.includes(token.nickname)}
              ></ConfirmAttendanceButton>
            </AttendantsSection>
            <CommentSection>
              <SmallTitle 
                description={"Comentários"}
                aditionalStyles={SmallTitleCustomStyles}
              ></SmallTitle>
              <CommentDiv>
                <CommentInput 
                  onChange={event => setCommentInput(event.target.value)}
                  type="text"
                  placeholder="comente aqui..."
                  value={commentInput}
                ></CommentInput>
                <SendCommentButton 
                  eventId={eventData?.event.eventId}
                  authorId={token.nameid}
                  commentText={commentInput}
                  refetch={refetch}
                  eraseInput={setCommentInput}
                ></SendCommentButton>
              </CommentDiv>
              <CommentList
                commentList={eventData?.comments}
              ></CommentList>
            </CommentSection>
          </>
        </MainSection>
        <MyFooter></MyFooter>
      </>
    </MainBackgroundDiv>
  );
}

const Title = styled.h1`
  color: white;
  font-family: ${fonts.dateNumber};
  font-size: x-large;
  height: 2rem;
  padding-left: 2rem;
  margin-top: 2rem;
  margin-bottom: 2rem;
  width: 100%;
`;

const DescriptionBaloon = styled.div`
  background-color: ${colors.mainButtonBackground};
  border-radius: 1rem;
  display: flex;
  flex-direction: column;
  min-height: 20%;
  padding: 1rem;
  width: 80%;
`;

const DescriptionTitle = styled.h2`
  font-family: ${fonts.citiesFont};
  font-weight: 700;
  width: 100%;
`;

const Description = styled.p`
  font-family: ${fonts.citiesFont};
`;

const Author = styled.p`
  font-family: ${fonts.citiesFont};
`;

const TimeAndDateContainer = styled.div`
  align-items: flex-start;
  display: flex;
  flex-direction: column;
  padding: 0 1em 0 1em;
  width: 100%;
`;

const TimeAndDate = styled.h2`
  color: ${colors.titleInDarkBackground};
  font-family: ${fonts.citiesFont};
  font-weight: 600;
  margin: 0.5em 0 0.3em 0;
`;

const EventDate = styled.h3`
  color: ${colors.minorTitle};
  font-family: ${fonts.citiesFont};
  font-weight: 600;
`;

const AttendantsSection = styled.section`
  display: flex;
  justify-content: space-between;
  margin: 1rem 0 1rem 0;
  padding-left: 1em;
  width: 100%;
`;
const AttendantsContainer = styled.div`
  width: 60%;
`;
const AttendantName = styled.p`
  color: ${colors.titleInDarkBackground};
  font-family: ${fonts.citiesFont};
`;

const CommentSection = styled.section`
  display: flex;
  flex-direction: column;
  margin: 1rem 0 1rem 0;
  padding-left: 1rem;
  padding-right: 1rem;
  width: 100%;
`

const CommentDiv = styled.div`
  align-items: center;
  display: flex;
  justify-content: space-around;
`

const CommentInput = styled.input`
  background-color: ${colors.inputBackground2};
  border: none;
  height: 3rem;
  margin: 1rem 0 1rem 0;
  padding: 0.5em;
  width: 80%;

  &::placeholder {
    color: ${colors.lines};
    font-family: ${fonts.inputFont};
  }

  &:focus {
    color: white;
    font-family: ${fonts.inputFont};
  }

  &:not(:focus) {
    color: white;
    font-family: ${fonts.inputFont};
  }
`

