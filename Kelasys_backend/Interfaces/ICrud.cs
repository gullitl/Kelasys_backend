using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kelasys_backend.Interfaces {
    public interface ICrud<T> {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<bool>> Delete(int id);
        Task<ActionResult<T>> Create(T t);
        Task<ActionResult<bool>> Update(T t);
    }
}
