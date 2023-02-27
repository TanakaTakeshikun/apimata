using Microsoft.AspNetCore.Mvc;
using AI.Talk.Editor.Api;

namespace test.Controllers
{

    public class Rqdata
    {
        public int Pitch { get; set; }

        public string? Text { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class KuronekoController : ControllerBase
    {
        private TtsControl? _ttsControl;
        private string Startup(string text)
        {
            _ttsControl = new TtsControl();
            _ttsControl.Initialize("A.I.VOICE Editor");
            if (_ttsControl.Status == HostStatus.NotRunning)
            {
                // �z�X�g�v���O�������N������
                _ttsControl.StartHost();
            }
            _ttsControl.Connect();//�����ŃG���[(������l�����Ăق���)
            return "test";

        }
        [HttpGet]
        public Rqdata Get(int Pitch, string Text)
        {
            Rqdata pd = new()
            {
                Pitch = Pitch,
                Text = this.Startup(Text)
            };
            return pd;
        }
    }
}