import styled from "styled-components";
import { colors } from "../styles/colors";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCalendarPlus
} from "@fortawesome/free-solid-svg-icons";
import { sizes } from "../styles/sizes";
import { fonts } from "../styles/fonts";
import { useNavigate } from "react-router";


export function MyFooter() {
  const navigate = useNavigate();

  return (
    <Footer>
      <AddEventContainer>
        <CalendarAddIcon icon={faCalendarPlus}></CalendarAddIcon>
        <Iconlabel onClick={()=> navigate("/CreateEvent")}>Criar evento</Iconlabel>
      </AddEventContainer>
    </Footer>
  );
}

const Footer = styled.footer`
  background-color: ${colors.navFooterBackground};
  align-items: center;
  display: flex;
  flex: 1;
  justify-content: space-around;
  padding: 0 2rem 0 2rem;
  width: 100%;
`;


const AddEventContainer = styled.div`
  align-items: center;
  display: flex;
  flex-direction: column;
`

const CalendarAddIcon = styled(FontAwesomeIcon)`
  color: ${colors.footerIcons};
  font-size: ${sizes.footerIcons};
`;

const Iconlabel = styled.p`
  color: ${colors.footerIcons};
  font-family: ${fonts.citiesFont};
  font-weight: 600;
`
