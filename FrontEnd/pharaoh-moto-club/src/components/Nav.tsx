import styled from "styled-components";
import { colors } from "../styles/colors";
import { fonts } from "../styles/fonts";
import { sizes } from "../styles/sizes";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faLessThan } from "@fortawesome/free-solid-svg-icons";
import { useNavigate } from "react-router";
import mainApiClient from "../api/config/mainAxiosInstance";

export interface NavComponent{
  title: string;
}

export function Nav({title}: NavComponent) {
  const navigate = useNavigate();
  async function logOut(){
    try{
      var response = await mainApiClient.post('members/logout');
      if(response.status == 204){
        navigate('/');
      }
    }catch(error){
      console.log(error);
    }
  }

  return (
    <>
      <MyNav>
        <DivLessThan >
          <LessThanContainer  onClick={() => navigate(-1)}>
            <LessThan icon={faLessThan} ></LessThan>
          </LessThanContainer>
          <DivTitle>
            <Title>{title}</Title>
          </DivTitle>
        </DivLessThan>
        <LogOut onClick={() => logOut()}>Sair</LogOut>
      </MyNav>
    </>
  );
}

const MyNav = styled.nav`
  align-items: center;
  background-color: ${colors.navFooterBackground};
  display: flex;
  height: 5rem;
  justify-content: space-between;
  position: relative;
  width: 100%;
`;

const LessThanContainer = styled.div`
  z-index: 2;
  position: absolute;
`

const DivLessThan = styled.div`
  align-items: center;
  display: flex;
  height: 100%;
  width: 100%;
  z-index: 1;
`;



const LessThan = styled(FontAwesomeIcon)`
  color: ${colors.label};
  font-size: 1.5rem;
  padding-left: 2rem;
  pointer-events: none;
`;

const LogOut = styled.a`
  color: ${colors.danger};
  font-family: ${fonts.citiesFont};
  font-weight: 700;
  padding-right: 2rem;
  z-index: 2;
`

const DivTitle = styled.div`
  align-items: center;
  display: flex;
  height: 100%;
  justify-content: center;
  position: absolute;
  width: 100%;
  z-index: 1;
`;

const Title = styled.h1`
  color: ${colors.label};
  font-family: ${fonts.labelFont};
  font-size: ${sizes.navTitle};
`;
