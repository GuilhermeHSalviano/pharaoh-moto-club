import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import {Nav} from "../components/Nav"

export function Dashboard() {
  return (
    <>
      <MainBackgroundDiv>{
        <>
            <Nav title={"DASHBOARD"}></Nav>
        </>
        }</MainBackgroundDiv>
    </>
  );
}
