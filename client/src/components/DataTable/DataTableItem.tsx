import { Box, Collapse, TableCell, TableRow } from '@mui/material';
import React, { useState } from 'react';

type DataTableItemProps = {
  el: {
    [key: string]: string;
  };
};

const DataTableItem = (props: DataTableItemProps): JSX.Element => {
  const { el } = props;
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
            <p>Більше інформації про {el.name}</p>
          </Box>
        </Collapse>
      </TableRow>
    </>
  );
};

export default DataTableItem;
