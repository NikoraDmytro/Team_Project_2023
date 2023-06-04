import React, { useEffect, useState } from 'react';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { JudgeForm } from '../../components/JudgeForm';
import { Judge } from '../../models/Judge';
import ClubService from '../../services/ClubService';
import BeltService from '../../services/BeltService';
import JudgeCategoryService from '../../services/JudgeCategoryService';
import JudgeService from '../../services/JudgeService';

type ColumnsType = Judge & { controls: string };

const RefereesPage = () => {
  const [judges, setJudges] = useState<Judge[]>([]);
  const [clubs, setClubs] = useState<string[]>([]);
  const [belts, setBelts] = useState<string[]>([]);
  const [judgeCategories, setJudgeCategories] = useState<string[]>([]);
  const [open, setOpen] = useState(false);
  const [update, setUpdate] = useState(false);
  const [judge, setJudge] = useState<Judge>();

  const handleClose = () => setOpen(false);

  const fetchClubs = async () => {
    var clubs = (await ClubService.getAllClubs()).map(x => x.name);
    setClubs(clubs);
  };

  const fetchBelts = async () => {
    const response = await BeltService.getAllBelts();
    setBelts(response.map(x => x.rank));
  };

  const fetchJudges = async () => {
    const response = await JudgeService.getAllJudges();
    setJudges(response);
  };

  const fetchJudgeCategories = async () => {
    const response = await JudgeCategoryService.getAllJudgeCategories();
    setJudgeCategories(response.map(x => x.name));
  };

  useEffect(() => {
    fetchJudges();
    fetchClubs();
    fetchBelts();
    fetchJudgeCategories();
  }, []);

  const editJudge = async (item: Judge) => {
    setUpdate(true);
    setJudge(item);
    setOpen(true);
  };

  const createJudge = async () => {
    setUpdate(false);
    setOpen(true);
  };

  const columns: TableColumns<Judge, ColumnsType>[] = [
    {
      name: 'firstName',
      label: "Ім'я",
      sortable: true,
    },
    {
      name: 'lastName',
      label: 'Прізвище',
      sortable: true,
    },
    {
      name: 'patronymic',
      label: 'По-батькові',
      sortable: true,
    },
    {
      name: 'sex',
      label: 'Стать',
    },
    {
      name: 'birthDate',
      label: 'Дата народження',
      sortable: true,
    },
    {
      name: 'belt',
      label: 'Пояс',
    },
    {
      name: 'judgeCategory',
      label: 'Суддівська категорія',
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
    {
      name: 'controls',
      renderItem: (item: Judge) => (
        <div className='control-buttons'>
          <EditIcon onClick={() => editJudge(item)} />
          <DeleteIcon className='delete-icon' />
        </div>
      ),
    },
  ];
  return (
    <div className='wrapper'>
      <div className='menu'>
        <TextField label='Пошук'></TextField>
        <div className='filter-buttons'>
          <div className='first-buttons'>
            <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
            <SelectForFilter label='Пояс' items={belts} />
          </div>
          <div className='second-buttons'>
            <SelectForFilter label='Клуб' items={clubs} />
            <SelectForFilter label='Категорія' items={judgeCategories} />
          </div>
        </div>
        <Button
          variant='contained'
          color='inherit'
          onClick={() => createJudge()}
        >
          Додати суддю
        </Button>
      </div>

      <DataTable tableData={judges} tableColumns={columns} />
      <JudgeForm
        open={open}
        update={update}
        judge={judge}
        setClose={handleClose}
      />
    </div>
  );
};

export { RefereesPage };
