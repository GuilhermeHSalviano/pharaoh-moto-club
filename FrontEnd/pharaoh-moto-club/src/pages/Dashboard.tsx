import styled from "styled-components";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import { DashboardCard } from "../components/DashboardCard";

export function Dashboard() {
  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"DASHBOARD"}></Nav>
            <MainSection>
              <WelcomeDiv/>
                <DashboardCard />
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
`
