import styled from "styled-components";
import { colors } from "../styles/colors";
import { sizes } from "../styles/sizes";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCheckToSlot } from "@fortawesome/free-solid-svg-icons";

export function DashboardCard() {
  return (
    <CardDiv>
      <IconDiv>
        <Icon icon={faCheckToSlot}/>
      </IconDiv>
    </CardDiv>
  );
}

const CardDiv = styled.div`
  background-color: ${colors.footerIcons};
  border-radius: 1rem;
  box-shadow: ${sizes.dashboardCardShadow};
  display: flex;
  height: 8rem;
  margin: 2rem 0 2rem 0;
  width: 80%;
`;

const IconDiv = styled.div`
  align-items: center;
  display: flex;
  height: 100%;
  justify-content: center;
  width: 30%;
`;

const Icon = styled(FontAwesomeIcon)`
    color: ${colors.mainButtonBackground};
    font-size: 3rem;
`
