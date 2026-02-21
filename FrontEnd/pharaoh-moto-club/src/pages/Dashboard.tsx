import styled from "styled-components";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import { DashboardCard } from "../components/DashboardCard";
import ballot_box from "../assets/box-ballot.svg";
import location_icon from "../assets/locationIcon.png";

export function Dashboard() {
  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"DASHBOARD"}></Nav>
            <MainSection>
              <WelcomeDiv />
              <DashboardCard
                image={ballot_box}
                title={"Eleições"}
                subtitle={"Votar e acompanhar os resultados"}
              />
              <DashboardCard
                image={location_icon}
                title={"Eventos"}
                subtitle={"Próximos eventos e localização"}
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
  height: 82%;
  width: 100%;
`;

const WelcomeDiv = styled.div`
  height: 3rem;
  width: 100%;
`;


