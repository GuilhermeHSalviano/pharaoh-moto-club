import styled from "styled-components";
import { colors } from "../styles/colors";
import { Fragment } from "react/jsx-runtime";
import type { PropsWithChildren } from "react";


export function MainBackgroundDiv({children}: PropsWithChildren) {
  return (
    <Fragment>
        <BackgroundDiv>{children}</BackgroundDiv>
    </Fragment>
  )
}

const BackgroundDiv = styled.div`
  align-items: center;
  background-color: ${colors.mainBackground};
  display: flex;
  flex-direction: column;
  justify-content: start;
  height: 100dvh;
  overflow: auto;
  width: 100dvw;
`;

