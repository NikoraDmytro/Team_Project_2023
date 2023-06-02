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
}

const SelectForFilter = ({ label, items }: SelectProps) => {
  const [value, setValue] = React.useState('');

  const handleChange = (event: SelectChangeEvent) => {
    setValue(event.target.value as string);
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
