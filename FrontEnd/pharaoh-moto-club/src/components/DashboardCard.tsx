import styled from "styled-components";
import { colors } from "../styles/colors";
import { sizes } from "../styles/sizes";
import { fonts } from "../styles/fonts";
import goImage from "../assets/go.png";

interface PropsDashboardCard {
  image: string;
  title: string;
  subtitle: string;
}

export function DashboardCard({ image, title, subtitle }: PropsDashboardCard) {
  return (
    <CardDiv>
      <IconDiv>
        <Icon src={image} />
      </IconDiv>
      <DescriptionDiv>
        <Title>{title}</Title>
        <Subtitle>{subtitle}</Subtitle>
      </DescriptionDiv>
      <GoDiv>
        <GoImage src={goImage}/>
      </GoDiv>
    </CardDiv>
  );
}

const CardDiv = styled.div`
  background-color: ${colors.footerIcons};
  border-radius: 1rem;
  box-shadow: ${sizes.dashboardCardShadow};
  display: flex;
  height: 8rem;
  margin: 2rem 0 2rem 0;
  width: 80%;

  &:active{
    opacity: 70%;
  }
`;

const IconDiv = styled.div`
  align-items: center;
  display: flex;
  height: 100%;
  justify-content: center;
  width: 30%;
`;

const Icon = styled.img`
  color: ${colors.mainButtonBackground};
  font-size: 3rem;
`;

const DescriptionDiv = styled.div`
  justify-content: center;
  display: flex;
  flex-direction: column;
  height: 100%;
  width: 50%;
`;

const Title = styled.h2`
  color: ${colors.label};
  font-family: ${fonts.cardFont};
  font-size: 1.3rem;
`;

const Subtitle = styled.h3`
  text-shadow: 3px 3px 7px black;
  color: ${colors.lines};
  font-family: ${fonts.cardFont};
`;

const GoDiv = styled.div`
  align-items: center;
  display: flex;
  flex-grow: 1;
  justify-content: center;
`;

const GoImage = styled.img`
  height: 1rem;
  width: 0.7rem;
`
