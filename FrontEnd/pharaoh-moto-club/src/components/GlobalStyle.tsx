import { createGlobalStyle } from "styled-components";

export function MyGlobalStyle(){
    return(
        <GlobalStyle></GlobalStyle>
    )
}

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