import React from "react";
import { Radio } from "@digdir/design-system-react";

interface FormRadioProps {
  name: string;
  question: string;
  choices: string[];
}

export const FormRadio: React.FC<FormRadioProps> = ({ question, name, choices }) => {
  return (
    <>
      <Radio.Group name={name} legend={question}>
        {choices.map((choice, index) => (
          <Radio key={index} value={choice} defaultChecked={index == 0}>
            {choice}
          </Radio>
        ))}
      </Radio.Group>
    </>
  );
};
