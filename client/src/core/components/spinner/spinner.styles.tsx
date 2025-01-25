import styled from 'styled-components';

export const SpinnerContainer = styled.div`
  position: relative;
  text-align: center;
  width: 100%;

  & > span {
    display: inline-block;
    background-color: var(--color-grey-400);
    width: 0.625rem;
    height: 0.625rem;
    margin-inline: 0.0625rem;
    border-radius: 100%;
    animation: bounce 1.4s infinite ease-in-out both;
  }

  & > span:nth-of-type(1) {
    animation-delay: -0.32s;
  }

  & > span:nth-of-type(2) {
    animation-delay: -0.16s;
  }

  & > span:nth-of-type(3) {
    animation-delay: -0.32s;
  }

  @keyframes bounce {
    0%,
    80%,
    100% {
      transform: scale(0);
    }

    40% {
      transform: scale(1);
    }
  }
`;
