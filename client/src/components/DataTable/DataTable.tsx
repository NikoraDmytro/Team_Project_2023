import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
  TableSortLabel,
  Avatar,
} from '@mui/material';
import React, { useState } from 'react';
import { WithId, TableColumns } from '../../types/DataTableTypes';

interface TableProps<T extends WithId, P extends T> {
  tableData: T[];
  tableColumns: TableColumns<T, P>[];
}

const DataTable = <T extends WithId, P extends T>(props: TableProps<T, P>) => {
  const [sortColumn, setSortColumn] = useState('');
  const [sortDirection, setSortDirection] = useState('asc');
  const { tableData, tableColumns } = props;
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);

  const handleChangePage = (event: unknown, newPage: number) => {
    console.log('change page to', newPage);
    setPage(newPage);
  };
  
  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const handleSort = (column: any) => {
    if (sortColumn === column) {
      setSortDirection(sortDirection === 'asc' ? 'desc' : 'asc');
    } else {
      setSortColumn(column);
      setSortDirection('asc');
    }
  };

  return (
    <>
      <Table stickyHeader>
        <TableHead>
          <TableRow>
            {tableColumns.map(column => (
              <TableCell key={String(column.name)}>
                {column.sortable ? (
                  <TableSortLabel
                    active={sortColumn === column.name}
                    direction={sortColumn === column.name ? (sortDirection === 'asc' ? 'asc' : 'desc') : 'asc'}
                    onClick={() => handleSort(column.name)}
                  >
                    {column.label}
                  </TableSortLabel>
                ) : (
                  column.label
                )}
              </TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {tableData.map(item => (
            <TableRow key={item.id}>
              {tableColumns.map(column => (
                <TableCell key={String(column.name)}>
                  {column.renderItem
                    ? column.renderItem(item)
                    : item[column.name as string] || (
                        <Avatar src={item[column.name as string]} />
                      )}
                </TableCell>
              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <TablePagination
        rowsPerPageOptions={[5, 10, 25]}
        component='div'
        count={tableData.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </>
  );
};

export { DataTable };
