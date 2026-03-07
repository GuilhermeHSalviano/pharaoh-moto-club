import styled from "styled-components";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import { DashboardCard } from "../components/DashboardCard";
import ballot_box from "../assets/box-ballot.svg";
import location_icon from "../assets/locationIcon.png";
import { TokenContext } from "../components/TokenContext";
import { useContext } from "react";
import { jwtDecode } from "jwt-decode";
import { colors } from "../styles/colors";
import { fonts } from "../styles/fonts";
import { sizes } from "../styles/sizes";

interface Jwt{
  name: string,
  nickname: string
}

export function Dashboard() {
  const token: Jwt = jwtDecode(useContext(TokenContext));

  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"DASHBOARD"}></Nav>
            <MainSection>
              <WelcomeDiv>
                <WelcomeTitle>Bem vindo:</WelcomeTitle>
                <WelcomeSubtitle>{token.nickname}</WelcomeSubtitle>
              </WelcomeDiv>
              <DashboardCard
                image={ballot_box}
                title={"Eleições"}
                subtitle={"Votar e acompanhar os resultados"}
                link={"/dashboard"}
              />
              <DashboardCard
                image={location_icon}
                title={"Eventos"}
                subtitle={"Próximos eventos e localização"}
                link={"/events"}
              />
            </MainSection>
            <MyFooter></MyFooter>
          </>
        }
      </MainBackgroundDiv>
    </>
  );
}

const MainSection = styled.main`
  align-items: center;
  flex-direction: column;
  display: flex;
  min-height: ${sizes.mainSection};
  width: 100%;
`;

const WelcomeDiv = styled.div`
  display: flex;
  flex-direction: column;
  height: 3rem;
  width: 80%;
`;

const WelcomeTitle = styled.h2`
  color: ${colors.mainButtonBackground};
  font-family: ${fonts.labelFont};
  font-size: 1rem;
  margin: 0.5rem 0 0 0;
`

const WelcomeSubtitle = styled.h3`
  color: ${colors.label};
  font-family: ${fonts.labelFont};
  font-size: 1.5rem;
`


