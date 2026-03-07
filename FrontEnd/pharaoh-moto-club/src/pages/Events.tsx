import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import { Nav } from "../components/Nav";
import { MyFooter } from "../components/MyFooter";
import styled from "styled-components";
import { sizes } from "../styles/sizes";

export function Events() {
  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <Nav title={"Eventos por estado"}></Nav>
            <MainSection></MainSection>
            <MyFooter></MyFooter>
          </>
        }
      </MainBackgroundDiv>
    </>
  );
}

const MainSection = styled.section`
    min-height: ${sizes.mainSection};
    width: 100%;
`
