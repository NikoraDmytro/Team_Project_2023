import { Box, Collapse, TableCell, TableRow } from '@mui/material';
import React, { useState } from 'react';

type CalendarItemProps = {
  el: {
    name: string;
    weightingDate: string;
    startDate: string;
    endData: string;
    city: string;
    status: string;
    level: string;
  };
};

const CalendarItem = ({ el }: CalendarItemProps): JSX.Element => {
  const [open, setOpen] = useState(false);
  return (
    <>
      <TableRow>
        {Object.values(el).map((val, id) => (
          <TableCell key={id} onClick={() => setOpen(!open)}>
            {val}
          </TableCell>
        ))}
      </TableRow>
      <TableRow>
        <Collapse in={open} timeout='auto' unmountOnExit>
          <Box>
            <p>Більше інформації про змагання {el.name}</p>
          </Box>
        </Collapse>
      </TableRow>
    </>
  );
};

export default CalendarItem;
