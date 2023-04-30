import {
  Button,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
  TextField,
} from '@mui/material';
import React, { useState } from 'react';
import DataTableItem from './DataTableItem';

interface TableColumns {
  name: string;
  sortable?: boolean;
}

interface TableRows {
  [key: string]: string;
}

interface TableProps {
  tableRows: TableRows[];
  tableColumns: TableColumns[];
}

const DataTable = (props: TableProps) => {
  const { tableRows, tableColumns } = props;
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };
  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  return (
    <div className='calendar-wrapper'>
      <div className='calendar-menu'>
        <TextField label='місце для пошуку'></TextField>
        <TextField label='місце для фільтрації'></TextField>
        <Button variant='contained'>Додати змагання</Button>
      </div>
      <Table stickyHeader>
        <TableHead>
          <TableRow>
            {tableColumns.map((el, id) => (
              <TableCell key={id}>{el.name}</TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {tableRows.map((el, id) => (
            <DataTableItem key={id} el={el} />
          ))}
        </TableBody>
      </Table>
      <TablePagination
        rowsPerPageOptions={[5, 10, 25]}
        component='div'
        count={tableRows.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </div>
  );
};

export { DataTable };
