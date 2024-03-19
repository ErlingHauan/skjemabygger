import { z, ZodNumber, ZodOptional, ZodString } from "zod";
import { TFunction } from "i18next";
import React from "react";
import { Alert } from "@digdir/design-system-react";

export const cleanFormData = (formData: FormData) => {
  const obj = Object.fromEntries(formData);
  const newObj = {};

  // Zod does not validate numbers correctly if given empty string
  for (const key in obj) {
    const value = obj[key];
    newObj[key] = value === "" ? undefined : value;
  }

  return newObj;
};

export const generateValidationSchema = (form: Form) => {
  let validator: ZodString | ZodNumber | ZodOptional<ZodString> | ZodOptional<ZodNumber>;
  const schemaShape: Record<string, typeof validator> = {};

  form.components.forEach((component) => {
    if (component.inputType === "number") {
      validator = getNumberValidator(component);
    } else {
      validator = getStringValidator(component);
    }

    schemaShape[component.name] = validator;
  });

  return z.object(schemaShape);
};

const getStringValidator = (component: FormComponent) => {
  let validator: ZodString | ZodOptional<ZodString>;

  validator = z.string({
    required_error: "Field is required. ",
  });

  if (!component.required) {
    validator = validator.optional();
  }

  if (component.minLength) {
    if (validator instanceof ZodString) {
      validator = validator.min(component.minLength, {
        message: `Field must have at least ${component.minLength} characters. `,
      });
    }
  }

  if (component.maxLength) {
    if (validator instanceof ZodString) {
      validator = validator.max(component.maxLength, {
        message: `Field must have more than ${component.maxLength} characters. `,
      });
    }
  }

  return validator;
};

const getNumberValidator = (component: FormComponent) => {
  let validator: ZodNumber | ZodOptional<ZodNumber>;

  validator = z.coerce.number({
    invalid_type_error: "Number required. ",
  });

  if (!component.required) {
    validator = validator.optional();
  }

  if (component.greaterThan) {
    if (validator instanceof ZodNumber) {
      validator = validator.gt(component.greaterThan, {
        message: `Number must be greater than ${component.greaterThan}. `,
      });
    }
  }

  if (component.lessThan) {
    if (validator instanceof ZodNumber) {
      validator = validator.lt(component.lessThan, {
        message: `Number must be less than ${component.lessThan}. `,
      });
    }
  }

  return validator;
};

export const alertToRender = (alertType: string, t: TFunction): React.JSX.Element => {
  if (alertType == "success") {
    return <Alert severity="success">{t("form_viewer.success")}</Alert>;
  } else if (alertType == "validationError") {
    return <Alert severity="danger">{t("form_viewer.validationError")}</Alert>;
  } else if (alertType == "serverError") {
    return <Alert severity="danger">{t("form_viewer.serverError")}</Alert>;
  }
};
