import { createGlobalStyle } from 'styled-components';

export default createGlobalStyle`
  :root {
    --color-beige-100: hsl(30, 36%, 96%);
    --color-beige-200: hsl(23, 6%, 57%);

    --color-blue-100: hsl(205, 48%, 47%);

    --color-brown-100: hsl(21, 30%, 44%);

    --color-cyan-100: hsl(190, 52%, 68%);

    --color-gold-100: hsl(47, 50%, 59%);

    --color-green-100: hsl(177, 52%, 32%);
    --color-green-200: hsl(83, 20%, 47%);

    --color-grey-100: hsl(0, 0%, 95%);    
    --color-grey-200: hsl(0, 0%, 70%);
    --color-grey-300: hsl(0, 0%, 41%);    
    --color-grey-400: hsl(252, 7%, 13%);
    --color-grey-500: hsl(214, 11%, 63%);

    --color-magenta-100: hsl(332, 30%, 44%);

    --color-navy-100: hsl(248, 8%, 41%);

    --color-orange-100: hsl(18, 47%, 52%);

    --color-purple-100: hsl(288, 29%, 62%);
    --color-purple-200: hsl(259, 30%, 56%);

    --color-red-100: hsl(7, 58%, 50%);

    --color-yellow-100: hsl(28, 73%, 81%);

    --color-turquoise-100: hsl(180, 16%, 42%);

    --color-white-100: hsl(0, 0%, 100%);
  }

  html {
    box-sizing: border-box;
  }

  body {
    font-family: "Public Sans", serif;
    background-color: var(--color-beige-100);
    color: var(--color-grey-400);
    line-height: 1.3;
  }

  *, *::before, *::after {
    box-sizing: inherit;
    padding: 0;
    margin: 0;
  }
`;
