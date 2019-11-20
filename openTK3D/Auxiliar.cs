using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;

namespace openTK3D
{
    class Auxiliar
    {
        public void horizontal(int x, int y, int z, int cx, int cy, Color cor)
        {
            GL.Color3(cor);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x + cx, y, z);
            GL.Vertex3(x + cx, y + cy, z);
            GL.Vertex3(x, y + cy, z);
            GL.End();
        }

        public void horizontal(int x, int y, int z, int cx, int cy, int textura, int repeticao)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, repeticao);
            GL.Vertex3(x, y, z);
            GL.TexCoord2(repeticao, repeticao);
            GL.Vertex3(x + cx, y, z);
            GL.TexCoord2(repeticao, 0);
            GL.Vertex3(x + cx, y + cy, z);
            GL.TexCoord2(0, 0);
            GL.Vertex3(x, y + cy, z);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

        public void verticalx(int x, int y, int z, int cx, int cz, Color cor)
        {
            GL.Color3(cor);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x + cx, y, z);
            GL.Vertex3(x + cx, y, z + cz);
            GL.Vertex3(x, y, z + cz);
            GL.End();
        }

        public void verticalx(int x, int y, int z, int cx, int cz, int textura)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex3(x, y, z);
            GL.TexCoord2(1, 1);
            GL.Vertex3(x + cx, y, z);
            GL.TexCoord2(1, 0);
            GL.Vertex3(x + cx, y, z + cz);
            GL.TexCoord2(0, 0);
            GL.Vertex3(x, y, z + cz);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

        public void verticaly(int x, int y, int z, int cy, int cz, Color cor)
        {
            GL.Color3(cor);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x, y + cy, z);
            GL.Vertex3(x, y + cy, z + cz);
            GL.Vertex3(x, y, z + cz);
            GL.End();
        }

        public void verticaly(int x, int y, int z, int cy, int cz, int textura)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex3(x, y, z);
            GL.TexCoord2(1, 1);
            GL.Vertex3(x, y + cy, z);
            GL.TexCoord2(1, 0);
            GL.Vertex3(x, y + cy, z + cz);
            GL.TexCoord2(0, 0);
            GL.Vertex3(x, y, z + cz);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }


        public void diagonalx(int x, int y, int z, int cx, int cy, int cz, Color cor)
        {
            GL.Color3(cor);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x + cx, y, z + cz);
            GL.Vertex3(x + cx, y + cy, z + cz);
            GL.Vertex3(x, y + cy, z);
            GL.End();
        }

        public void diagonaly(int x, int y, int z, int cx, int cy, int cz, Color cor)
        {
            GL.Color3(cor);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x, y + cy, z + cz);
            GL.Vertex3(x + cx, y + cy, z + cz);
            GL.Vertex3(x + cx, y, z);
            GL.End();
        }

        public void diagonalx(int x, int y, int z, int cx, int cy, int cz, int textura, int repeticao)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, repeticao);
            GL.Vertex3(x, y, z);
            GL.TexCoord2(repeticao, repeticao);
            GL.Vertex3(x + cx, y, z + cz);
            GL.TexCoord2(repeticao, 0);
            GL.Vertex3(x + cx, y + cy, z + cz);
            GL.TexCoord2(0, 0);
            GL.Vertex3(x, y + cy, z);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

        public void diagonaly(int x, int y, int z, int cx, int cy, int cz, int textura, int repeticao)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, repeticao);
            GL.Vertex3(x, y, z);
            GL.TexCoord2(repeticao, repeticao);
            GL.Vertex3(x, y + cy, z + cz);
            GL.TexCoord2(repeticao, 0);
            GL.Vertex3(x + cx, y + cy, z + cz);
            GL.TexCoord2(0, 0);
            GL.Vertex3(x + cx, y, z);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

        public void desenhaparedex(int x, int y, int z, int cx, int cz, int espessura, Color cor1, Color cor2, Color cor3)
        {
            this.verticalx(x, y, z, cx, cz, cor1);
            this.verticalx(x, y + espessura, z, cx, cz, cor2);
            this.horizontal(x, y, z, cx, espessura, cor3);
            this.horizontal(x, y, z + cz, cx, espessura, cor3);
            this.verticaly(x, y, z, espessura, cz, cor3);
            this.verticaly(x + cx, y, z, espessura, cz, cor3);
        }

        public void desenhaparedey(int x, int y, int z, int cy, int cz, int espessura, Color cor1, Color cor2, Color cor3)
        {
            this.verticaly(x, y, z, cy, cz, cor1);
            this.verticaly(x + espessura, y, z, cy, cz, cor2);
            this.horizontal(x, y, z, espessura, cy, cor3);
            this.horizontal(x, y, z + cz, espessura, cy, cor3);
            this.verticalx(x, y, z, espessura, cz, cor3);
            this.verticalx(x, y + cy, z, espessura, cz, cor3);
        }

        public void desenhaparedex(int x, int y, int z, int cx, int cz, int espessura, Color cor, int textura, int repeticao)
        {
            this.verticalx(x, y, z, cx, cz, textura);
            this.verticalx(x, y + espessura, z, cx, cz, textura);
            this.horizontal(x, y, z, cx, espessura, textura,repeticao);
            this.horizontal(x, y, z + cz, cx, espessura, textura,repeticao);
            this.verticaly(x, y, z, espessura, cz, textura);
            this.verticaly(x + cx, y, z, espessura, cz, textura);
        }

        public void desenhaparedey(int x, int y, int z, int cy, int cz, int espessura, Color cor, int textura, int repeticao)
        {
            this.verticaly(x, y, z, cy, cz, textura);
            this.verticaly(x + espessura, y, z, cy, cz, textura);
            this.horizontal(x, y, z, espessura, cy, textura,repeticao);
            this.horizontal(x, y, z + cz, espessura, cy, textura,repeticao);
            this.verticalx(x, y, z, espessura, cz, textura);
            this.verticalx(x, y + cy, z, espessura, cz, textura);
        }

        public void desenhaparedex2(int x, int y, int z, int cx, int cz, int espessura, Color cor, int textura, bool sentido, int repeticao)
        {
            if (sentido == true)
            {
                this.verticalx(x, y, z, cx, cz, textura);
                this.verticalx(x, y + espessura, z, cx, cz, cor);
            }
            else
            {
                this.verticalx(x, y, z, cx, cz, cor);
                this.verticalx(x, y + espessura, z, cx, cz, textura);
            }
            this.horizontal(x, y, z, cx, espessura, textura, repeticao);
            this.horizontal(x, y, z + cz, cx, espessura, textura,repeticao);
            this.verticaly(x, y, z, espessura, cz, textura);
            this.verticaly(x + cx, y, z, espessura, cz, textura);
        }

        public void desenhaparedey2(int x, int y, int z, int cy, int cz, int espessura, Color cor, int textura, bool sentido,int repeticao)
        {
            if (sentido == true)
            {
                this.verticaly(x, y, z, cy, cz, textura);
                this.verticaly(x + espessura, y, z, cy, cz, cor);
            }
            else
            {
                this.verticaly(x, y, z, cy, cz, cor);
                this.verticaly(x + espessura, y, z, cy, cz, textura);
            }

            this.horizontal(x, y, z, espessura, cy, textura,repeticao);
            this.horizontal(x, y, z + cz, espessura, cy,textura, repeticao);
            this.verticalx(x, y, z, espessura, cz, textura);
            this.verticalx(x, y + cy, z, espessura, cz, textura);
        }

        public void desenhaparedex2(int x, int y, int z, int cx, int cz, int espessura, int texturaI, int textura, bool sentido, int repeticao)
        {
            if (sentido == true)
            {
                this.verticalx(x, y, z, cx, cz, textura);
                this.verticalx(x, y + espessura, z, cx, cz, texturaI);
            }
            else
            {
                this.verticalx(x, y, z, cx, cz, texturaI);
                this.verticalx(x, y + espessura, z, cx, cz, textura);
            }
            this.horizontal(x, y, z, cx, espessura, textura,repeticao);
            this.horizontal(x, y, z + cz, cx, espessura, textura,repeticao);
            this.verticaly(x, y, z, espessura, cz, textura);
            this.verticaly(x + cx, y, z, espessura, cz, textura);
        }

        public void desenhaparedey2(int x, int y, int z, int cy, int cz, int espessura, int texturaI, int textura, bool sentido, int repeticao)
        {
            if (sentido == true)
            {
                this.verticaly(x, y, z, cy, cz, textura);
                this.verticaly(x + espessura, y, z, cy, cz, texturaI);
            }
            else
            {
                this.verticaly(x, y, z, cy, cz, texturaI);
                this.verticaly(x + espessura, y, z, cy, cz, textura);
            }

            this.horizontal(x, y, z, espessura, cy, textura,repeticao);
            this.horizontal(x, y, z + cz, espessura, cy, textura,repeticao);
            this.verticalx(x, y, z, espessura, cz, textura);
            this.verticalx(x, y + cy, z, espessura, cz, textura);
        }

        public void desenhaparedex3(int x, int y, int z, int cx, int cz, int espessura, Color cor, int textura)
        {
            this.verticalx(x, y, z, cx, cz, textura);
            this.verticalx(x, y + espessura, z, cx, cz, textura);
            this.horizontal(x, y, z, cx, espessura, cor);
            this.horizontal(x, y, z + cz, cx, espessura, cor);
            this.verticaly(x, y, z, espessura, cz, cor);
            this.verticaly(x + cx, y, z, espessura, cz, cor);
        }

        public void desenhaparedey3(int x, int y, int z, int cy, int cz, int espessura, Color cor, int textura)
        {
            this.verticaly(x, y, z, cy, cz, textura);
            this.verticaly(x + espessura, y, z, cy, cz, textura);
            this.horizontal(x, y, z, espessura, cy, cor);
            this.horizontal(x, y, z + cz, espessura, cy, cor);
            this.verticalx(x, y, z, espessura, cz, cor);
            this.verticalx(x, y + cy, z, espessura, cz, cor);
        }

        public void desenhaparedeh(int x, int y, int z, int cx, int cy, int espessura, Color cor)
        {
            this.horizontal(x, y, z, cx, cy, cor);
            this.horizontal(x, y, z + espessura, cx, cy, cor);
            this.verticalx(x, y, z, cx, espessura, cor);
            this.verticalx(x, y + cy, z, cx, espessura, cor);
            this.verticaly(x, y, z, cy, espessura, cor);
            this.verticaly(x + cx, y, z, cy, espessura, cor);
        }

        public void desenhaparedeh(int x, int y, int z, int cx, int cy, int espessura, Color cor, int textura, bool sentido, int repeticao)
        {
            if (sentido == true)
            {
                this.horizontal(x, y, z, cx, cy, textura,repeticao);
                this.horizontal(x, y, z + espessura, cx, cy, cor);
            }           
            else{
                this.horizontal(x, y, z, cx, cy, cor);
                this.horizontal(x, y, z + espessura, cx, cy, textura,repeticao);
            }
            this.verticalx(x, y, z, cx, espessura, cor);
            this.verticalx(x, y + cy, z, cx, espessura, cor);
            this.verticaly(x, y, z, cy, espessura, cor);
            this.verticaly(x + cx, y, z, cy, espessura, cor);
        }

        public void desenhaquarto(int x, int y, int z, int cx, int cy, int cz, int espessura, Color cor, int textura, int texturachao, int repeticao)
        {
            this.desenhaparedey2(x, y, z, cy, cz, espessura, cor, textura, true,repeticao);
            this.desenhaparedex2(x + espessura, y, z, cx, cz, espessura, cor, textura, true,repeticao);
            this.desenhaparedey2(x + espessura + cx, y, z, cy, cz, espessura, cor, textura, false,repeticao);
            this.desenhaparedex2(x + 2 * espessura + cx, y + cy, z, -1 * (cx + 2*espessura), cz, espessura, cor, textura, false,repeticao);
            this.desenhaparedeh(x, y, z, cx+10, cy, -10, Color.White, texturachao, true,repeticao);
            this.desenhaparedeh(x, y, z + 140, cx + 10, cy, -10, Color.White);
        }

        public void desenhaquarto(int x, int y, int z, int cx, int cy, int cz, int espessura, int texturaI, int textura, int texturachao, int repeticao)
        {
            this.desenhaparedey2(x, y, z, cy, cz, espessura, texturaI, textura, true,repeticao);
            this.desenhaparedex2(x + espessura, y, z, cx, cz, espessura, texturaI, textura, true,repeticao);
            this.desenhaparedey2(x + espessura + cx, y, z, cy, cz, espessura, texturaI, textura, false,repeticao);
            this.desenhaparedex2(x + 2 * espessura + cx, y + cy, z, -1 * (cx + 2 * espessura), cz, espessura, texturaI, textura, false,repeticao);
            this.desenhaparedeh(x, y, z, cx+10, cy, -10, Color.White, texturachao, true,repeticao);
            this.desenhaparedeh(x, y, z + 140, cx + 10, cy, -10, Color.White);
        }

    }
}
