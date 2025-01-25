import { LogoContainer } from './logo.styles';

import LargeLogo from '../../../assets/logo-large.svg';

export function Logo() {
  return (
    <LogoContainer>
      <img src={LargeLogo} alt="Finance Logo" />
    </LogoContainer>
  );
}
