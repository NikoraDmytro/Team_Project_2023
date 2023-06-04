import React, { useEffect, useState } from 'react';
import { DataTable } from '../../components/DataTable';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import { TableColumns } from '../../types/DataTableTypes';
import { TextField } from '@mui/material';
import belts from '../../const/belts';
import './DivisionPage.scss';
import { Division } from '../../models/Division';
import DivisionService from '../../services/DivisionService';
import { Belt } from '../../models/Belt';
import BeltService from '../../services/BeltService';

type ColumnsType = Division & { controls: string };

const DivisionsPage = () => {
  const [divisions, setDivisions] = useState<Division[]>([]);
  const [open, setOpen] = useState(false);
  const [belts, setBelts] = useState<string[]>([]);

  const handleClose = () => setOpen(false);

  const fetchDivisions = async () => {
    const response = await DivisionService.getAllDivisions();

    setDivisions(response.data);
  };

  const fetchBelts = async () => {
    const response = await BeltService.getAllBelts();
    console.log(response.data)
    setBelts(response.data.map(x => x.rank));
  }

  useEffect(() => {
    fetchDivisions();
    fetchBelts();
  }, []);

  const columns: TableColumns<Division, ColumnsType>[] = [
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'sex',
      label: 'Стать',
    },
    {
      name: 'minWeight',
      label: 'Мінімальна вага',
      sortable: true,
    },
    {
      name: 'maxWeight',
      label: 'Максимальна вага',
      sortable: true,
    },
    {
      name: 'minAge',
      label: 'Мінімальний вік',
      sortable: true,
    },
    {
      name: 'maxAge',
      label: 'Максимальний вік',
      sortable: true,
    },
    {
      name: 'minBelt',
      label: 'Мінімальний пояс',
      sortable: true,
    },
    {
      name: 'maxBelt',
      label: 'Максимальний пояс',
      sortable: true,
    },
  ];
  return (
    <div className='wrapper'>
      <div className='divisions-menu'>
        <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
        <TextField label='Мін вага' />
        <TextField label='Макс вага' />
        <TextField label='Мін вік' />
        <TextField label='Макс вік' />
        <SelectForFilter label='Мін пояс' items={belts} />
        <SelectForFilter label='Макс пояс' items={belts} />
      </div>

      <DataTable tableData={divisions} tableColumns={columns} />
    </div>
  );
};

export { DivisionsPage };

const test = [
  {
    id: 1,
    name: 'Назва дивізіону',
    sex: 'Ч',
    minWeight: '72,5 кг',
    maxWeight: '72,5 кг',
    minAge: '19',
    maxAge: '21',
    minBelt: '1 куп',
    maxBelt: '1 дан',
  },
  {
    id: 2,
    name: 'Назва дивізіону',
    sex: 'Ч',
    minWeight: '72,5 кг',
    maxWeight: '72,5 кг',
    minAge: '19',
    maxAge: '21',
    minBelt: '1 куп',
    maxBelt: '1 дан',
  },
  {
    id: 3,
    name: 'Назва дивізіону',
    sex: 'Ч',
    minWeight: '72,5 кг',
    maxWeight: '72,5 кг',
    minAge: '19',
    maxAge: '21',
    minBelt: '1 куп',
    maxBelt: '1 дан',
  },
  {
    id: 4,
    name: 'Назва дивізіону',
    sex: 'Ч',
    minWeight: '72,5 кг',
    maxWeight: '72,5 кг',
    minAge: '19',
    maxAge: '21',
    minBelt: '1 куп',
    maxBelt: '1 дан',
  },
  {
    id: 5,
    name: 'Назва дивізіону',
    sex: 'Ч',
    minWeight: '72,5 кг',
    maxWeight: '72,5 кг',
    minAge: '19',
    maxAge: '21',
    minBelt: '1 куп',
    maxBelt: '1 дан',
  },
];
