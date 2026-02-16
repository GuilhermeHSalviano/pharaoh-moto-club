/* eslint-disable @typescript-eslint/no-unused-vars */
import { MainBackgroundDiv } from "./components/MainBackgroundDiv.tsx";
import styled from "styled-components";
import seven from "./assets/seven.png";
import {colors} from "./styles/colors.tsx";
import { sizes } from "./styles/sizes.tsx";
import { MyInput } from "./components/Input.tsx";
import { useState } from "react";

function App() {
  const [userName, setUserName] = useState<string>();

  return (
    <>
      <MainBackgroundDiv>
        {
          <>
            <DivSeven>
              <Seven
                src={seven}
                alt="Imagem de um sete, um dos símbolos do motoclub"
              />
            </DivSeven>
            <DivLogin>
              <DivInput>
                <MyInput setValue={setUserName}></MyInput>
              </DivInput>
            </DivLogin>
          </>
        }
      </MainBackgroundDiv>
    </>
  );
}

const Seven = styled.img`
  width: 90%;
  object-fit: contain;
`;
const DivSeven = styled.div`
  align-items: center;
  display: flex;
  flex-direction: column;
  width: 100%;
`;
const DivLogin = styled.div`
  flex-grow: 1;
  padding: 0 3rem 0 3rem;
  width: 100%;
`;

const DivInput = styled.div`
  border-left: solid ${sizes.widthlines};
  border-color: ${colors.lines};
  height: 60%;
  width: 100%;
`

export default App;
