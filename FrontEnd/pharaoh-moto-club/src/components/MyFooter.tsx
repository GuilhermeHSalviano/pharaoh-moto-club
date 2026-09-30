import styled from "styled-components";
import { colors } from "../styles/colors";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCalendarPlus, faPenToSquare
} from "@fortawesome/free-solid-svg-icons";
import { sizes } from "../styles/sizes";
import { fonts } from "../styles/fonts";
import { useNavigate } from "react-router";


export function MyFooter() {
  const navigate = useNavigate();

  return (
    <Footer>
      <IconContainer onClick={()=> navigate("/CreateEvent")}>
        <CalendarAddIcon icon={faCalendarPlus}></CalendarAddIcon>
        <Iconlabel>Criar evento</Iconlabel>
      </IconContainer>
      <IconContainer onClick={()=> navigate("/eventsByAuthor")}>
        <EditEventIcon icon={faPenToSquare}></EditEventIcon>
        <Iconlabel>Editar meus eventos</Iconlabel>
      </IconContainer>
    </Footer>
  );
}

const Footer = styled.footer`
  background-color: ${colors.navFooterBackground};
  align-items: center;
  display: flex;
  flex-grow: 1;
  justify-content: space-around;
  padding: 0 2rem 0 2rem;
  width: 100%;
`;


const IconContainer = styled.div`
  align-items: center;
  display: flex;
  flex-direction: column;
`

const CalendarAddIcon = styled(FontAwesomeIcon)`
  color: ${colors.footerIcons};
  font-size: ${sizes.footerIcons};
`;

const EditEventIcon = styled(FontAwesomeIcon)`
  color: ${colors.footerIcons};
  font-size: ${sizes.footerIcons};
`

const Iconlabel = styled.p`
  color: ${colors.footerIcons};
  font-family: ${fonts.citiesFont};
  font-weight: 600;
`
