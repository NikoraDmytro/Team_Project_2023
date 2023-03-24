import React from 'react';
import { Field} from 'formik';
import { TextField } from '@mui/material';

interface Props {
  name: string;
  type: string;
  label: string;
}

const InputFormField: React.FC<Props> = (props) => {
  return (
    <Field
        name={props.name}
        type={props.type}
        label={props.label}
        as={TextField}
        fullWidth
    />
  )
}

export default InputFormField