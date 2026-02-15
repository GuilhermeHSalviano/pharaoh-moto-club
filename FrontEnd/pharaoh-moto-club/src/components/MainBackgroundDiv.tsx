import styled, { createGlobalStyle } from "styled-components";
import { colors } from "../styles/colors";
import { Fragment } from "react/jsx-runtime";
import type { PropsWithChildren } from "react";


export function MainBackgroundDiv({children}: PropsWithChildren) {
  return (
    <Fragment>
        <GlobalStyle/>
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
  height: 100%;
  width: 100%;
`;

const GlobalStyle = createGlobalStyle`
     /* A modern CSS reset */
  *, *::before, *::after {
    box-sizing: border-box;
  }
  * {
    margin: 0;
    padding: 0;
    font: inherit; /* Inherit fonts for form controls */
  }
  html, body {
    height: 100%;
  }
  body {
    line-height: 1.5;
    -webkit-font-smoothing: antialiased;
  }
  img, picture, video, canvas, svg {
    display: block;
    max-width: 100%;
  }
  input, button, textarea, select {
    font: inherit;
  }
  p, h1, h2, h3, h4, h5, h6 {
    overflow-wrap: break-word;
  }
  ul, ol {
    list-style: none;
  }
  /* End of modern CSS reset */

  /* Your additional global styles */
  a {
    text-decoration: none;
    color: inherit;
  }
`;
