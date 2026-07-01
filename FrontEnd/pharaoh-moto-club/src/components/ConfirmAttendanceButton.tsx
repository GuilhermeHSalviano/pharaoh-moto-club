import { useEffect, useState } from "react";
import styled from "styled-components";
import {
  quitEvent,
  confirmAttendance,
} from "../api/config/services/attendanceService";
import { colors } from "../styles/colors";
import { fonts } from "../styles/fonts";

interface Props {
  eventId: string;
  memberId: string;
  refetch: Function;
  hasMemberConfirmedAttendance: boolean;
}

export default function ConfirmAttendanceButton({
  eventId,
  memberId,
  refetch,
  hasMemberConfirmedAttendance,
}: Props) {
  const [backgroundColor, setBackgroundColor] = useState<string>("");

  useEffect(() => {
    hasMemberConfirmedAttendance
      ? setBackgroundColor(colors.quitAttendance)
      : setBackgroundColor(colors.confirmAttendance);
  }, [hasMemberConfirmedAttendance]);

  async function setAttendance() {
    if (hasMemberConfirmedAttendance == false) {
      await confirmAttendance(eventId, memberId);
    } else {
      await quitEvent(eventId, memberId);
    }
    refetch();
  }

  return (
    <Button
      onClick={() => setAttendance()}
      style={{ backgroundColor: backgroundColor }}
    >
      {hasMemberConfirmedAttendance ? "Não vou" : "Eu vou"}
    </Button>
  );
}

const Button = styled.button`
  border: none;
  border-radius: 1rem;
  font-family: ${fonts.citiesFont};
  font-weight: 600;
  height: 2rem;
  margin: 1em;
  width: 7em;
`;
