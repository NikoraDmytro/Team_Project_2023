import React from 'react';
import { Field, useField} from 'formik';
import { TextField } from '@mui/material';

interface Props {
  name: string;
  type: string;
  label: string;
}

const InputFormField = (props: Props): JSX.Element => {
  const [field, meta] = useField(props.name);
  return (
    <Field
      {...field}
      type={props.type}
      label={props.label}
      as={TextField}
      fullWidth
      error={meta.touched && !!meta.error}
      helperText={meta.touched && meta.error}
    />
  )
}

export { InputFormField }