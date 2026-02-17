/* eslint-disable @typescript-eslint/no-unused-vars */
import { MainBackgroundDiv } from "./components/MainBackgroundDiv.tsx";
import styled from "styled-components";
import seven from "./assets/seven.png";
import { colors } from "./styles/colors.tsx";
import { sizes } from "./styles/sizes.tsx";
import { MyInput } from "./components/Input.tsx";
import { useState } from "react";
import { fonts } from "./styles/fonts.tsx";
import { MainButton } from "./components/MainButton.tsx";

function App() {
  const [userName, setUserName] = useState<string>();

  function teste(): void {
    console.log("olá mundo");
  }

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
                <MyLabel htmlFor="user">Usuário</MyLabel>
                <MyInput
                  setValue={setUserName}
                  type={"email"}
                  width={"100%"}
                  name={"usuario"}
                  placeholder="digite seu usuário aqui"
                  id="user"
                ></MyInput>
                <MyLabel htmlFor="password">Senha</MyLabel>
                <MyInput
                  setValue={setUserName}
                  type={"password"}
                  width={"100%"}
                  name={"senha"}
                  placeholder={"digite sua senha"}
                  id="password"
                ></MyInput>
              </DivInput>
              <MainButton title={"entrar"} doOnClick={teste}></MainButton>
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
  height: 65dvh;
  width: 100%;
`;
const DivLogin = styled.div`
  align-items: center;
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  padding: 0 3rem 0 2rem;
  width: 100%;
`;

const DivInput = styled.div`
  border-left: solid ${sizes.widthlines};
  border-color: ${colors.lines};
  display: flex;
  flex-direction: column;
  height: 60%;
  padding: 0 1rem 0 1rem;
  width: 100%;
`;

const MyLabel = styled.label`
  color: ${colors.label};
  font-family: ${fonts.labelFont};
  font-size: ${sizes.labelSize};
  width: 100%;
`;

export default App;
