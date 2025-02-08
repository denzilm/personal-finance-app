import styled from 'styled-components';
import { respond } from '../../mixins.styles';

export const LogoContainer = styled.div`
  display: flex;
  justify-content: center;
  border-radius: 0 0 7px 7px;
  background-color: var(--color-grey-400);

  ${respond.desktop` display: none;`}
`;
export const SignInContentContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  max-width: 35rem;
  margin-inline: auto;

  ${respond.desktop`
      padding: 1rem;
      gap: 18.75rem;
      max-width: initial;
    `}
`;
export const SignInFormContainer = styled.div`
  width: 50rem;
  ${respond.desktop`
    flex-basis: 50rem;
  `}
`;

export const SignInLinkContainer = styled.p`
  margin-top: 2rem;
  font-size: 0.875rem;
  font-weight: 500;
  color: var(--color-grey-300);
  text-align: center;
`;
