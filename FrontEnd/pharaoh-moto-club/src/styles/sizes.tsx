import { colors } from "./colors";
import { fonts } from "./fonts";

export const sizes = {
  widthlines: "1px",
  inputShadow: "1px 1px 5px 0.1px #0000009d inset",
  borderInput: "8px",
  labelSize: "2em",
  inputHight: "2.5rem",
  borderButton: "8px",
  widthButton: "7rem",
  heightButton: "2.5rem",
  buttonShadow: "2px 2px 5px 0.1px #000000",
  dashboardCardShadow: "0 2px 5px 0.1px #000000",
  navTitle: "2rem",
  footerIcons: "1.7rem",
  mainSection: "79vh"
};

export const genericInput = {
  backgroundColor: `${colors.inputBackground}`,
  boxShadow: `${sizes.inputShadow}`,
  borderRadius: `${sizes.borderInput}`,
  border: "none",
  paddingLeft: `1rem`,

  placeholder:{
    color: `${colors.lines}`,
    fontFamily: `${fonts.inputFont}`
  },

  focus:{
    color: '#ffffff',
    fontFamily: `${fonts.inputFont}`
  },

  not:{
    color: "'#ffffff'",
    fontFamily: `${fonts.inputFont}`
  }
}