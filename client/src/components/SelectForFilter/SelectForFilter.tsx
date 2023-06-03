import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
} from '@mui/material';
import React, { useState } from 'react';

interface SelectProps {
  label: string;
  items: string[];
  name?: string;
  setFieldValue?: (
    field: string,
    value: any,
    shouldValidate?: boolean | undefined,
  ) => void;
}

const SelectForFilter = ({
  label,
  items,
  name,
  setFieldValue,
}: SelectProps) => {
  const [value, setValue] = React.useState('');

  const handleChange = (event: SelectChangeEvent) => {
    const selectedValue = event.target.value as string;
    setValue(selectedValue);
    if (setFieldValue) {
      name
        ? setFieldValue(name, selectedValue)
        : setFieldValue(label, selectedValue);
    }
  };
  return (
    <FormControl fullWidth>
      <InputLabel id='select-label'>{label}</InputLabel>
      <Select
        labelId='select-label'
        id='select'
        value={value}
        label={label}
        onChange={handleChange}
      >
        {items.map(item => (
          <MenuItem key={item} value={item}>
            {item}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
};

export default SelectForFilter;
