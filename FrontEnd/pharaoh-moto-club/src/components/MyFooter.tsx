import styled from "styled-components";
import { colors } from "../styles/colors";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCalendarDays,
  faCheckToSlot,
} from "@fortawesome/free-solid-svg-icons";
import { sizes } from "../styles/sizes";

export function MyFooter() {
  return (
    <Footer>
      <Callendar icon={faCalendarDays} />
      <Elections icon={faCheckToSlot} />
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

const Callendar = styled(FontAwesomeIcon)`
  color: ${colors.footerIcons};
  font-size: ${sizes.footerIcons};
`;

const Elections = styled(FontAwesomeIcon)`
  color: ${colors.footerIcons};
  font-size: ${sizes.footerIcons};
`;
