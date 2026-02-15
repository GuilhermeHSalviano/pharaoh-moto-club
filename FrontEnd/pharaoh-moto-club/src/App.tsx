import { MainBackgroundDiv } from "./components/MainBackgroundDiv.tsx";
import styled from "styled-components";
import seven from "./assets/seven.png";

function App() {
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
            <DivLogin></DivLogin>
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
  width: 100%;
`;

export default App;
