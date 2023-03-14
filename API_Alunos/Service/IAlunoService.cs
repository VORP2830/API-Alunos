﻿using API_Alunos.Models;

namespace API_Alunos.Service
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<IEnumerable<Aluno>> GetAlunosByNome(string Nome);  
        Task CreateAluno(Aluno aluno);
        Task UpdateAluno (Aluno aluno); 
        Task DeleteAluno (Aluno aluno);
    }
}
