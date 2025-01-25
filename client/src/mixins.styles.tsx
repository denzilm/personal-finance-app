import { css } from 'styled-components';

export const respond = {
  tablet: (...arguments_: Parameters<typeof css>) => css`
    @media (min-width: 48em) {
      ${css(...arguments_)}
    }
  `,
  desktop: (...arguments_: Parameters<typeof css>) => css`
    @media (min-width: 90em) {
      ${css(...arguments_)}
    }
  `
};
