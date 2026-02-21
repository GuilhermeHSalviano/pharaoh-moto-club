import styled from "styled-components";
import { colors } from "../styles/colors";
import { fonts } from "../styles/fonts";
import { sizes } from "../styles/sizes";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faLessThan } from "@fortawesome/free-solid-svg-icons";
import { useNavigate } from "react-router";

export interface NavComponent{
  title: string;
}

export function Nav({title}: NavComponent) {
  const navigate = useNavigate()

  return (
    <>
      <MyNav>
        <DivLessThan onClick={() => navigate(-1)}>
          <LessThan icon={faLessThan}></LessThan>
          <DivTitle>
            <Title>{title}</Title>
          </DivTitle>
        </DivLessThan>
      </MyNav>
    </>
  );
}

const MyNav = styled.nav`
  align-items: center;
  background-color: ${colors.navFooterBackground};
  display: flex;
  height: 5rem;
  position: relative;
  width: 100%;
`;

const DivLessThan = styled.div`
  align-items: center;
  display: flex;
  height: 100%;
  justify-content: start;
  position: absolute;
  width: 100%;
  z-index: 2;
`;

const LessThan = styled(FontAwesomeIcon)`
  color: ${colors.label};
  font-size: 1.5rem;
  padding-left: 2rem;
`;

const DivTitle = styled.div`
  align-items: center;
  display: flex;
  height: 100%;
  justify-content: center;
  position: absolute;
  width: 100%;
  z-index: 1;
`;

const Title = styled.h1`
  color: ${colors.label};
  font-family: ${fonts.labelFont};
  font-size: ${sizes.navTitle};
`;
