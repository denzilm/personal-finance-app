import { LandingPageGraphicContainer } from './landing-page-graphic.styles';

import LargeLogo from '../../../assets/logo-large.svg';

export function LandingPageGraphic() {
  return (
    <LandingPageGraphicContainer>
      <img src={LargeLogo} alt="Finance Logo" />
      <div>
        <span>Keep track of your money and save for your future</span>
        <span>
          Personal finance app puts you in control of your spending. Track transactions, set budgets, and add to savings
          pots easily
        </span>
      </div>
    </LandingPageGraphicContainer>
  );
}
