import styled from 'styled-components';

import { respond } from '../../../mixins.styles';

export const LandingPageGraphicContainer = styled.div`
  display: none;
  ${respond.desktop`
    display: block;
    height: calc(100vh - 2rem);
    background-image: url(./illustration-authentication.svg);
    background-repeat: no-repeat;
    flex-basis: 37.5rem;
    border-radius: 1rem;
    background-size: cover;
    background-position: center;
    position: relative;
    

    img {
      margin: 3.75rem;
    }

    span {
      color: var(--color-white-100);
      display: block;
      position: absolute;
      padding: 2.5rem;
    }

    span:first-of-type {
      bottom: 4.5rem;
      font-size: 2rem;
      font-weight: 700;
    }

    span:last-of-type {
      font-size: 0.75rem;
      bottom: 1.95rem;
    }
  `}
`;
