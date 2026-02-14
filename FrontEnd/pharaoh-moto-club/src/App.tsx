import styled from "styled-components";
import {colors} from "./styles/colors.tsx";

function App() {
  return (
    <>
      <Teste>Olá mundo</Teste>
    </>
  );
}

const Teste = styled.h1`
    font-size: 50px;
    color: ${colors.mainBackground}
`;
export default App;
